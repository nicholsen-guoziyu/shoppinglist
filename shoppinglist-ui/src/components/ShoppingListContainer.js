import React, { Component } from "react";
import Calendar from './controls/Calendar';
import ShoppingListItem from './ShoppingListItem'
class ShoppingListContainer extends Component
{
    constructor(props)
    {
        super(props);
        
        this.state = { 
            items = [{selectedFile:null, store:"", itemName:"", itemBrand:"", itemQuantity:"", itemPrice:"", itemPriority:"", itemStatus:"", itemRemark:"", itemImageName:""}],
            filterText = '',
        }

        this.retrieveItems = this.retrieveItems.bind(this);
        this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleFileChange = this.handleFileChange.bind(this);
        this.handleNewItem = this.handleNewItem.bind(this);
        this.handleItemAdded = this.handleItemAdded.bind(this);
        this.handleItemDeleted = this.handleItemDeleted.bind(this);
        this.handleImageUpdated = this.handleImageUpdated.bind(this);
        this.handleItemCollected = this.handleItemCollected.bind(this);
    }

    retrieveItems = (selectedDate) => {
        //query API to get the items based on selected date argument and call the below setState to rerender the shoppingform
        //this retrieveItems need to be passed in as props so it can be called by the calendar component
        this.setState({ items: null })
    }

    handleFilterTextChange(filterText) {
        this.setState({
          filterText: filterText
        });
      }

    handleInputChange(event)
    {
        let items = [...this.state.items];
        items[event.target.dataset.id][event.target.dataset.name] = event.target.value;
        this.setState({ items });
    }

    handleFileChange(event)
    {
        let items = [...this.state.items];
        items[event.target.dataset.id][event.target.dataset.name] = event.target.files[0];
        this.setState({ items });
    }

    handleNewItem()
    {
        this.setState((prevState) => ({
            items: [...prevState.items, {selectedFile:null, store:"", itemName:"", itemBrand:"", itemQuantity:"", itemPrice:"", itemPriority:"", itemStatus:"", itemRemark:"", itemImageName:""}],
          }));
    }

    handleItemAdded(event, itemId, itemImageName)
    {
        let items = [...this.state.items];
        items[event.target.dataset.id]["itemId"] = itemId;
        items[event.target.dataset.id]["itemImageName"] = itemImageName;
        this.setState({ items });
    }

    handleItemDeleted(event)
    {
        let items = [...this.state.items];
        items.splice(event.target.dataset.id, 1)
        this.setState({ items });
    }

    handleImageUpdated(event, imageName)
    {
        let items = [...this.state.items];
        items[event.target.dataset.id]["selectedFile"] = null;
        items[event.target.dataset.id]["imageName"] = imageName;
        this.setState({ items });
    }

    handleItemCollected(event)
    {
        let items = [...this.state.items];
        items[event.target.dataset.id]["itemStatus"] = "Collected";
        this.setState({ items });
    }

    render()
    {
        let {filterText, items} = this.state
        return (
        <div class="ShoppingListContainer">
        <form action="#">
            <button type="button" class="btn" id="DateLookup"><i class="fa fa-bars"></i></button>
            <input type="text" id="SearchText" placeholder="Search Item" onClick={this.handleFilterTextChange} />
            <button class="btn"><i class="fa fa-plus-square"></i></button>
            <Calendar onDateClick={this.retrieveItems}></Calendar>
            
                <ShoppingListItem items={this.items} filterText={filterText} 
                                    onItemAdded={this.handleItemAdded}
                                    onImageUpdated = {this.handleImageUpdated}
                                    onItemDeleted = {this.handleItemDeleted}
                                    onItemCollected = {this.handleItemCollected}
                                    onFileChanged = {this.handleFileChange}
                                    onInputChanged = {this.handleInputChange}>
                </ShoppingListItem>
            
            <button type="button" class="addNewButton" onClick={this.handleNewItem}>Add New Item</button>
            <div class="ShoppingListTotal">
                <label class="item">Total </label>
                <label class="item">$129.00 </label>
            </div>
        </form>
        </div>)
    }
}