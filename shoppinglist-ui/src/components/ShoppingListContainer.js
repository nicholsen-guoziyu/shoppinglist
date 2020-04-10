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

    handleInputChange = (event) =>
    {
        let items = [...this.state.items];
        items[e.target.dataset.id][e.target.className] = e.target.value;
        this.setState({ items });
    }

    handleNewItem()
    {
        //setState to add new item into the items
    }

    handleAddItem(event, index, itemId, itemImageName)
    {
        //update the items in the specified index with the new value of itemId and itemImageName
        //setState
    }

    handleDeleteItem(event, index)
    {
        //remove new item from items
        //setState
    }

    handleUpdateImage(event, index, imageName)
    {
        //setState on imageName for specified item based on its index 
    }

    handleItemCollected(itemId)
    {
        //modify the items to update the status to Collected for the specified itemId
        //setState for items
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
                        
                    </div>
                    <button type="button" class="addNewButton">Add New Item</button>
                    <div class="ShoppingListTotal">
                        <label class="item">Total </label>
                        <label class="item">$129.00 </label>
                    </div>
                </form>
            </div>
        )
    }
}