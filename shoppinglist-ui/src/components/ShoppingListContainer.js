import React, { Component } from "react";
import Calendar from './controls/Calendar';
import ShoppingListItem from './ShoppingListItem'
import ShoppingListTotal from './ShoppingListTotal'
class ShoppingListContainer extends Component
{
    constructor(props)
    {
        super(props);
        
        this.state = { 
            items = [{index:0, selectedFile:null, store:"", itemName:"", itemBrand:"", itemQuantity:"", itemPrice:"", itemPriority:"", itemStatus:"", itemRemark:"", itemImageName:""}],
            filteredItems = [],
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

    componentWillMount() {
        this.setState({
          items,
          filteredItems: items
        })
      }

    retrieveItems = (selectedDate) => {
        //query API to get the items based on selected date argument and call the below setState to rerender the shoppingform
        //this retrieveItems need to be passed in as props so it can be called by the calendar component
        this.setState({ items: null })
    }

    handleFilterTextChange(filterText) {
        let filteredItems = this.state.items;
        filteredItems = filteredItems.filter((item) => {
            return ( 
                this.props.items[idx].store.indexOf(this.props.filterText) >= 0 ||
                this.props.items[idx].itemName.indexOf(this.props.filterText) >= 0 ||
                this.props.items[idx].itemBrand.indexOf(this.props.filterText) >= 0 ||
                this.props.items[idx].itemRemark.indexOf(this.props.filterText) >= 0
            ) 
        });
        this.setState({
            filteredItems
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
        items[event.target.dataset.index]["itemId"] = itemId;
        items[event.target.dataset.index]["itemImageName"] = itemImageName;
        this.setState({ items });
    }

    handleItemDeleted(event)
    {
        let items = [...this.state.items];
        items.splice(event.target.dataset.index, 1)
        this.setState({ items });
    }

    handleImageUpdated(event, imageName)
    {
        let items = [...this.state.items];
        items[event.target.dataset.index]["selectedFile"] = null;
        items[event.target.dataset.index]["imageName"] = imageName;
        this.setState({ items });
    }

    handleItemCollected(event)
    {
        let items = [...this.state.items];
        items[event.target.dataset.index]["itemStatus"] = "Collected";
        this.setState({ items });
    }

    render()
    {
        let {filterText, items, filteredItems} = this.state;
        return (
        <div class="ShoppingListContainer">
        <form action="#">
            <button type="button" class="btn" id="DateLookup"><i class="fa fa-bars"></i></button>
            <input type="text" id="SearchText" placeholder="Search Item" onClick={this.handleFilterTextChange} />
            <button class="btn"><i class="fa fa-plus-square"></i></button>
            <Calendar onDateClick={this.retrieveItems}></Calendar>
            <ShoppingListItem items={this.filteredItems} filterText={filterText} 
                                onItemAdded={this.handleItemAdded}
                                onImageUpdated = {this.handleImageUpdated}
                                onItemDeleted = {this.handleItemDeleted}
                                onItemCollected = {this.handleItemCollected}
                                onFileChanged = {this.handleFileChange}
                                onInputChanged = {this.handleInputChange}>
            </ShoppingListItem>
            <button type="button" class="addNewButton" onClick={this.handleNewItem}>Add New Item</button>
            <ShoppingListTotal items={this.filteredItems}></ShoppingListTotal>
        </form>
        </div>)
    }
}