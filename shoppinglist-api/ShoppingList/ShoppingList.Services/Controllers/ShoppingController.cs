using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.ShoppingDomain;
using ShoppingList.Business.ShoppingDomain.Model;
using ShoppingList.Core.Web.Image;
using ShoppingList.Data;
using ShoppingList.Services.Model.Shopping;

namespace ShoppingList.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingBusiness  _shoppingBusiness;

        //TODO change the below url to dynamic URL using URL object
        private const string _itemImageUrlPrefix = "https://localhost:44367/shopping/shoppingitemimage/";
        
        public ShoppingController(IShoppingBusiness shoppingBusiness)
        {
            _shoppingBusiness = shoppingBusiness;
        }

        [HttpGet("{shoppingDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(DateTime shoppingDate)
        {
            //TODO check if current log in user is the same userId or if different, then whether the current logged in user has access to this user id. Otherwise return unauthorized
            var shopping = await _shoppingBusiness.GetShopping(shoppingDate);
            if(shopping == null)
            {
                //TODO redirect to Create Shopping page
            }
            PaginatedList<ShoppingItem> shoppingItems = await _shoppingBusiness.GetShoppingItems(shopping.Id, 1, 100);
            List<long> shoppingItemIdList = new List<long>();
            foreach(ShoppingItem shoppingItem in shoppingItems)
            {
                shoppingItemIdList.Add(shoppingItem.Id);
            }
            PaginatedList<ShoppingItemImage> shoppingItemImages = await _shoppingBusiness.GetShoppingItemImages(shoppingItemIdList, 1, 100);

            List<ShoppingItemModel> shoppingItemModelList = new List<ShoppingItemModel>();
            if(shoppingItems == null || shoppingItems.Count() <= 0)
            {
                ShoppingItemModel shoppingItemModel = new ShoppingItemModel();
                shoppingItemModelList.Add(shoppingItemModel);
            }
            else
            {
                int counter = 0;

                foreach(ShoppingItem shoppingItem in shoppingItems)
                {
                    ShoppingItemModel shoppingItemModel = new ShoppingItemModel();
                    shoppingItemModel.Index = counter;
                    shoppingItemModel.Id = shoppingItem.Id;
                    shoppingItemModel.Store = shoppingItem.Store;
                    shoppingItemModel.ItemName = shoppingItem.ItemName;
                    shoppingItemModel.ItemBrand = shoppingItem.ItemBrand;
                    shoppingItemModel.ItemQuantity = shoppingItem.ItemQuantity;
                    shoppingItemModel.ItemPrice = shoppingItem.ItemPrice;
                    shoppingItemModel.ItemPriority = shoppingItem.ItemPriority;
                    shoppingItemModel.ItemStatus = shoppingItem.ItemStatus;
                    shoppingItemModel.ItemRemark = shoppingItem.ItemRemark;
                    
                    shoppingItemModel.ItemImageUrlList = new List<string>();

                    List<ShoppingItemImage> sortedImages = shoppingItemImages
                                    .Where(shoppingItemImage => shoppingItemImage.ShoppingItemId == shoppingItem.Id)
                                    .OrderBy(o => o.CreatedOnUtc).ToList();

                    foreach (ShoppingItemImage shoppingItemImage in sortedImages)
                    {
                        
                        shoppingItemModel.ItemImageUrlList.Add(_itemImageUrlPrefix + shoppingItemImage.Id.ToString());
                    }
                    
                    shoppingItemModelList.Add(shoppingItemModel);

                    counter++;
                }
            }

            ShoppingModel shoppingModel = new ShoppingModel();
            shoppingModel.Id = shopping.Id;
            shoppingModel.ShoppingItemModelList = shoppingItemModelList;

            return Ok(shoppingModel);
        }

        [HttpGet("shoppingitemimage/{shoppingItemImageId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetShoppingItemImage(long shoppingItemImageId)
        {
            //TODO validate this shoppingItemImageId belong to the current logged in user

            ShoppingItemImage shoppingItemImage = await _shoppingBusiness.GetShoppingItemImage(shoppingItemImageId);
            if (shoppingItemImage != null)
            {
                return File(shoppingItemImage.ImageFile, 
                    ImageHelper.GetContentType(System.IO.Path.GetExtension(shoppingItemImage.ImageName)), 
                    shoppingItemImage.ImageName);
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateShopping(DateTime shoppingDate)
        {
            //TODO validate shoppingDate argument to make sure it is valid date
            if (ModelState.IsValid)
            {
                long shoppingId = 0;
                Shopping shopping = await _shoppingBusiness.GetShopping(shoppingDate);
                if (shopping == null || shopping.Id <= 0)
                {
                    Shopping newShopping = new Shopping();
                    newShopping.UserId = 1;
                    newShopping.ShoppingDate = shoppingDate;
                    newShopping.CreatedOnUtc = DateTime.UtcNow;
                    shoppingId = await _shoppingBusiness.CreateShopping(newShopping);
                }
                else
                {
                    shoppingId = shopping.Id;
                }

                return Ok(shoppingId);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("shoppingItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm]ShoppingItemSaveRequestModel shoppingItemRequest, IFormFile imageFile)
        {
            if(ModelState.IsValid)
            {
                if(shoppingItemRequest.Id <= 0)
                {
                    ShoppingItem newShoppingItem = new ShoppingItem();
                    newShoppingItem.ShoppingId = shoppingItemRequest.ShoppingId;
                    newShoppingItem.Store = shoppingItemRequest.Store;
                    newShoppingItem.ItemName = shoppingItemRequest.ItemName;
                    newShoppingItem.ItemBrand = shoppingItemRequest.ItemBrand;
                    newShoppingItem.ItemQuantity = shoppingItemRequest.ItemQuantity;
                    newShoppingItem.ItemPrice = shoppingItemRequest.ItemPrice;
                    newShoppingItem.ItemPriority = shoppingItemRequest.ItemPriority;
                    newShoppingItem.ItemStatus = shoppingItemRequest.ItemStatus;
                    newShoppingItem.ItemRemark = shoppingItemRequest.ItemRemark;
                    newShoppingItem.CreatedOnUtc = DateTime.UtcNow;

                    long shoppingItemId = await _shoppingBusiness.CreateShoppingItem(newShoppingItem);
                    long shoppingItemImageId = 0;
                    if (imageFile != null)
                    {
                        ShoppingItemImage newShoppingItemimage = new ShoppingItemImage();
                        newShoppingItemimage.ShoppingItemId = shoppingItemId;

                        //TODO manipulate image name to prevent duplicate for every upload
                        newShoppingItemimage.ImageName = shoppingItemRequest.ImageName;
                        
                        using (var stream = new MemoryStream())
                        {
                            imageFile.OpenReadStream().CopyTo(stream);
                            newShoppingItemimage.ImageFile = stream.ToArray();
                        }
                        newShoppingItemimage.CreatedOnUtc = DateTime.UtcNow;

                        shoppingItemImageId = await _shoppingBusiness.CreateShoppingItemImage(newShoppingItemimage);
                    }

                    ShoppingItemSaveResponseModel response = new ShoppingItemSaveResponseModel();
                    response.ShoppingItemId = shoppingItemId;
                    response.ShoppingItemImageUrl = _itemImageUrlPrefix + shoppingItemImageId.ToString();

                    return Ok(response);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("shoppingItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromForm]ShoppingItemSaveRequestModel shoppingItemRequest, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                //TODO validate this shopping item id and shopping id belong to the current logged in user
                //TODO validate this shopping item id is belong to the current shopping id and shopping date

                ShoppingItem shoppingItem = await _shoppingBusiness.GetShoppingItem(shoppingItemRequest.Id);
                shoppingItem.Store = shoppingItemRequest.Store;
                shoppingItem.ItemName = shoppingItemRequest.ItemName;
                shoppingItem.ItemBrand = shoppingItemRequest.ItemBrand;
                shoppingItem.ItemQuantity = shoppingItemRequest.ItemQuantity;
                shoppingItem.ItemPrice = shoppingItemRequest.ItemPrice;
                shoppingItem.ItemPriority = shoppingItemRequest.ItemPriority;
                shoppingItem.ItemStatus = shoppingItemRequest.ItemStatus;
                shoppingItem.ItemRemark = shoppingItemRequest.ItemRemark;

                await _shoppingBusiness.UpdateShoppingItem(shoppingItem);
                long shoppingItemImageId = 0;
                if (imageFile != null)
                {
                    ShoppingItemImage newShoppingItemimage = new ShoppingItemImage();
                    newShoppingItemimage.ShoppingItemId = shoppingItemRequest.Id;
                    //TODO manipulate image name to prevent duplicate
                    newShoppingItemimage.ImageName = shoppingItemRequest.ImageName;
                    using (var stream = new MemoryStream())
                    {
                        imageFile.OpenReadStream().CopyTo(stream);
                        newShoppingItemimage.ImageFile = stream.ToArray();
                    }
                    newShoppingItemimage.CreatedOnUtc = DateTime.UtcNow;

                    shoppingItemImageId = await _shoppingBusiness.CreateShoppingItemImage(newShoppingItemimage);
                }

                ShoppingItemSaveResponseModel response = new ShoppingItemSaveResponseModel();
                response.ShoppingItemId = shoppingItemRequest.Id;
                response.ShoppingItemImageUrl = _itemImageUrlPrefix + shoppingItemImageId.ToString();

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("shoppingItem/{shoppingItemId}")]
        public async Task<IActionResult> Delete(long shoppingItemId)
        {
            //TODO validate this shopping item id belong to the current logged in user

            await _shoppingBusiness.DeleteShoppingItemImages(shoppingItemId);
            await _shoppingBusiness.DeleteShoppingItem(shoppingItemId);

            return Ok();
        }
    }
}