using System;
using System.Collections.Generic;
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
                            shoppingItemModel.ItemImageUrlList.Add(Url.Action("Get", "ShoppingItemImage", new { id = shoppingItemImage.Id }));
                        }
                    }
                    shoppingItemModelList.Add(shoppingItemModel);
                }
            }

            return Ok(shoppingItemModelList);
        }
    }
}