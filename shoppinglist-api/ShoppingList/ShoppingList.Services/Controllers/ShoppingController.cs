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

            PaginatedList<ShoppingItem> shoppingItemList = await _shoppingBusiness.GetShoppingItems(shoppingDate);
            
            //TODO convert to api model


            return Ok();
        }
    }
}