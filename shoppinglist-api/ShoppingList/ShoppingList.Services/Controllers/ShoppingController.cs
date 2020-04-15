﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.ShoppingDomain;
using ShoppingList.Business.ShoppingDomain.Model;
using ShoppingList.Data;
using ShoppingList.Services.Model.Shopping;

namespace ShoppingList.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingBusiness  _shoppingBusiness;
        public ShoppingController(IShoppingBusiness shoppingBusiness)
        {
            _shoppingBusiness = shoppingBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]long userId, DateTime shoppingDate)
        {
            if(userId <= 0)
            {
                return NotFound();
            }

            //TODO check if current log in user is the same userId or if different, then whether the current logged in user has access to this user id. Otherwise return unauthorized

            PaginatedList<ShoppingItem> shoppingItems = await _shoppingBusiness.GetShoppingItems(shoppingDate, 0, int.MaxValue);
            List<long> shoppingItemIdList = new List<long>();
            foreach(ShoppingItem shoppingItem in shoppingItems)
            {
                shoppingItemIdList.Add(shoppingItem.Id);
            }
            PaginatedList<ShoppingItemImage> shoppingItemImages = await _shoppingBusiness.GetShoppingItemImages(shoppingItemIdList, 0, int.MaxValue);

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
                    shoppingItemModel.ItemName = shoppingItem.ItemName;
                    shoppingItemModel.ItemBrand = shoppingItem.ItemBrand;
                    shoppingItemModel.ItemQuantity = shoppingItem.ItemQuantity;
                    shoppingItemModel.ItemPrice = shoppingItem.ItemPrice;
                    shoppingItemModel.ItemPriority = shoppingItem.ItemPriority;
                    shoppingItemModel.ItemStatus = shoppingItem.ItemStatus;
                    shoppingItemModel.ItemRemark = shoppingItem.ItemRemark;
                    
                    shoppingItemModel.ItemImageUrlList = new List<string>();
                    foreach(ShoppingItemImage shoppingItemImage in shoppingItemImages)
                    {
                        if(shoppingItemImage.ShoppingItemId == shoppingItem.Id)
                        {
                            shoppingItemModel.ItemImageUrlList.Add(Url.Action("Get", 
                                "ShoppingItemImageController", new { id = shoppingItemImage.Id }));
                        }
                    }
                    
                    shoppingItemModelList.Add(shoppingItemModel);
                }
            }

            return Ok(shoppingItemModelList);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateShopping([FromQuery]DateTime shoppingDate)
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm]ShoppingItemSaveRequestModel shoppingItemRequest, IFormFile imageFile)
        {
            if(ModelState.IsValid)
            {
                long shoppingId = 0;
                if(shoppingItemRequest.Id <= 0)
                {
                    if(shoppingId > 0)
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
                        response.ShoppingItemImageId = shoppingItemImageId;

                        return Ok(response);
                    }
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
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
                response.ShoppingItemImageId = shoppingItemImageId;

                return Ok(response);
            }

            return BadRequest(ModelState);
        }
    }
}