import React, { Component } from "react";
import Calendar from './Calendar';
class ShoppingListContainer extends Component
{
    constructor(props)
    {
        super(props);
        
        this.state = { 
            items = null,
            filterText = '',
        }

        this.retrieveItems = this.retrieveItems.bind(this);
        this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
    }

    retrieveItems = selectedDate => {
        //query API to get the items based on selected date argument and call the below setState to rerender the shoppingform
        //this retrieveItems need to be passed in as props so it can be called by the calendar
        this.setState({ items: null })
    }

    handleFilterTextChange(filterText) {
        this.setState({
          filterText: filterText
        });
      }

      handleItemCollection(itemId)
      {
        //query API to change the status to Collected
        //modify the items to update the status to Collected for the specified itemId
        //setState for items
      }

      addNewItem()
      {
          //add new item to the items
          //setState for items
      }

      deleteNewItem()
      {
          //remove new item from items
          //setState for items
      }

      createItem()
      {
          //call the API to create new item
          //call retrieveItems to render again
      }

      updateItem()
      {
          //call the API to update item
          //call retrieveItems to render again
      }

      deleteItem()
      {
          //call the API to delete item
          //call retrieveItems to render again
      }

    render()
    {
        return
        (
            <div class="ShoppingListContainer">
                <form action="#">
                    <button type="button" class="btn" id="DateLookup"><i class="fa fa-bars"></i></button>
                    <input type="text" id="SearchText" placeholder="Search Item" />
                    <button class="btn"><i class="fa fa-plus-square"></i></button>
                    <Calendar onDateClick={this.retrieveItems}></Calendar>
                    <div class="ShoppingList">
                        <div class="ShoppingListItem">
                            <input class="ShoppingListItemCheckbox" type="checkbox" />
                            <button type="button" class="item item-header collapsible">Rice</button>
                            <div class="ShoppingListItemDetail collapsible-item hide">
                                <label class="item" for="File1">Upload File </label><input class="item" type="file" id="File1" name="File1" />
                                <label class="item" for="Store1">Store </label><input class="item" type="text" id="Store1" name="Store1" />
                                <label class="item" for="Name1">Name </label><input class="item" type="text" id="Name1" name="Name1" />
                                <label class="item" for="Brand1">Brand </label><input class="item" type="text" id="Brand1" name="Brand1" />
                                <label class="item" for="Quantity1">Quantity </label><input class="item" type="text" id="Quantity1" name="Quantity1" />
                                <label class="item" for="Price1">Price </label><input class="item" type="text" id="Price1" name="Price1" />
                                <label class="item" for="Priority1">Priority </label><select class="item" id="Priority1" name="Priority1">
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                </select>
                                <label class="item" for="Remark1">Remark </label><textarea class="item" rows="10" cols="30" name="Remark1"></textarea>
                                <img class="item-image"  />
                                <div class="ShoppingListItemAction">
                                    <button type="submit">Save</button>
                                    <button type="submit">Delete</button>
                                </div>
                            </div>
                        </div>
                        <div class="ShoppingListItem">
                            <input class="ShoppingListItemCheckbox" type="checkbox" />
                            <button type="button" class="item item-header collapsible">Rice</button>
                            <div class="ShoppingListItemDetail collapsible-item hide">
                                <label class="item" for="File1">Upload File </label><input class="item" type="file" id="File1" name="File1" />
                                <label class="item" for="Store1">Store </label><input class="item" type="text" id="Store1" name="Store1" />
                                <label class="item" for="Name1">Name </label><input class="item" type="text" id="Name1" name="Name1" />
                                <label class="item" for="Brand1">Brand </label><input class="item" type="text" id="Brand1" name="Brand1" />
                                <label class="item" for="Quantity1">Quantity </label><input class="item" type="text" id="Quantity1" name="Quantity1" />
                                <label class="item" for="Price1">Price </label><input class="item" type="text" id="Price1" name="Price1" />
                                <label class="item" for="Priority1">Priority </label><select class="item" id="Priority1" name="Priority1">
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                </select>
                                <label class="item" for="Remark1">Remark </label><textarea class="item" rows="10" cols="30" name="Remark1"></textarea>
                                <img class="item-image" src="https://ichef.bbci.co.uk/news/320/cpsprodpb/3B4B/production/_109897151_otternew.jpg" />
                                <div class="ShoppingListItemAction">
                                    <button type="submit">Save</button>
                                    <button type="submit">Delete</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="ShoppingListTotal">
                        <label class="item">Total </label>
                        <label class="item">$129.00 </label>
                    </div>
                </form>
            </div>
        )
    }
}