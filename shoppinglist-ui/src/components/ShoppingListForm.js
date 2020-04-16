import React, { Component } from "react";
import Calendar from './controls/Calendar';
import ShoppingList from './ShoppingList'
import ShoppingListTotal from './ShoppingListTotal'

class ShoppingListForm extends Component
{
    constructor(props)
    {
        super(props);
        this.item = {index:0, selectedFile:null, store:"", itemName:"", itemBrand:"", itemQuantity:"", itemPrice:0, itemPriority:1, itemStatus:1, itemRemark:"", itemImageName:""};
        this.state = { 
            error: null,
            isLoaded: false,
            items : [],
            filteredItems : [],
            filterText : '',
        }

        this.retrieveItems = this.retrieveItems.bind(this);
        this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
        this.handleDataBind = this.handleDataBind.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleFileChange = this.handleFileChange.bind(this);
        this.handleNewItem = this.handleNewItem.bind(this);
        this.handleItemAdded = this.handleItemAdded.bind(this);
        this.handleItemDeleted = this.handleItemDeleted.bind(this);
        this.handleImageUpdated = this.handleImageUpdated.bind(this);
        this.handleItemCollected = this.handleItemCollected.bind(this);
    }

    componentDidMount() {
        let search = window.location.search;
        let params = new URLSearchParams(search);
        let shoppingDate = params.get('shoppingDate');
        fetch("https://localhost:44367/api/shopping/" + shoppingDate)
        .then(res => res.json())
        .then(
            (result) => {
            this.setState({
                isLoaded: true,
                items: result,
                filteredItems: result
            });
            },
            // Note: it's important to handle errors here
            // instead of a catch() block so that we don't swallow
            // exceptions from actual bugs in components.
            (error) => {
                this.setState({
                    isLoaded: true,
                    error
                });
            }
        )
      }

    retrieveItems = (selectedDate) => {
        //query API to get the items based on selected date argument and call the below setState to rerender the shoppingform
        //this retrieveItems need to be passed in as props so it can be called by the calendar component
        this.setState({ items: null })
    }

    handleFilterTextChange(event) {
        this.setState({filterText : event.target.value}, () =>
            this.handleDataBind(this.state.filterText)
        );
    }

    handleDataBind(filterText)
    {
        let filteredItems = this.state.items;
        filteredItems = filteredItems.filter((item) => {
            return ( 
                item.store.indexOf(filterText) >= 0 ||
                item.itemName.indexOf(filterText) >= 0 ||
                item.itemBrand.indexOf(filterText) >= 0 ||
                item.itemRemark.indexOf(filterText) >= 0
            ) 
        });
        this.setState({
            filteredItems
        });
    }

    handleInputChange(event)
    {
        let items = [...this.state.items];
        items[event.target.dataset.index][event.target.dataset.name] = event.target.value;
        this.setState({ items }, () =>
            this.handleDataBind(this.state.filterText)
        );
    }

    handleFileChange(event)
    {
        let items = [...this.state.items];
        items[event.target.dataset.index][event.target.dataset.name] = event.target.files[0];
        this.setState({ items }, () =>
            this.handleDataBind(this.state.filterText)
        );
    }

    handleNewItem()
    {
        //for deep copy
        let newItem = JSON.parse(JSON.stringify(this.item));
        newItem.index = this.state.items.length;
        this.setState((prevState) => ({
            items: [...prevState.items, newItem],
            filteredItems: [...prevState.filteredItems, newItem],
        }));
    }

    handleItemAdded(event, itemId, itemImageName)
    {
        let items = [...this.state.items];
        items[event.target.dataset.index]["itemId"] = itemId;
        items[event.target.dataset.index]["itemImageName"] = itemImageName;
        this.setState({ items }, () =>
            this.handleDataBind(this.state.filterText)
        );
    }

    handleItemDeleted(event)
    {
        let items = [...this.state.items];
        items.splice(event.target.dataset.index, 1)
        this.setState({ items }, () =>
            this.handleDataBind(this.state.filterText)
        );
    }

    handleImageUpdated(event, imageName)
    {
        let items = [...this.state.items];
        items[event.target.dataset.index]["selectedFile"] = null;
        items[event.target.dataset.index]["imageName"] = imageName;
        this.setState({ items }, () =>
            this.handleDataBind(this.state.filterText)
        );
    }

    handleItemCollected(event)
    {
        let items = [...this.state.items];
        items[event.target.dataset.index]["itemStatus"] = "2";
        this.setState({ items }, () =>
            this.handleDataBind(this.state.filterText)
        );
    }

    handleItemCollapsible(event)
    {
        let items = [...this.state.items];
        items[event.target.dataset.index]["collapsed"] = !items[event.target.dataset.index]["collapsed"];
        this.setState({ items }, () =>
            this.handleDataBind(this.state.filterText)
        );
    }

    render()
    {
        const { error, isLoaded } = this.state;
        if (error) 
        {
            return <div>Error: {error.message}</div>;
        } 
        else if (!isLoaded) {
            return <div>Loading...</div>;
        } 
        else 
        {
            return (
                <form action="#">
                    <button type="button" className="btn" id="DateLookup"><i className="fa fa-bars"></i></button>
                    <input type="text" id="SearchText" placeholder="Search Item" onChange={this.handleFilterTextChange} value={this.state.filterText} />
                    <button className="btn"><i className="fa fa-plus-square"></i></button>
                    <Calendar onDateClick={this.retrieveItems}></Calendar>
                    <ShoppingList items={this.state.filteredItems} filterText={this.state.filterText} 
                                        onItemAdded={this.handleItemAdded}
                                        onImageUpdated = {this.handleImageUpdated}
                                        onItemDeleted = {this.handleItemDeleted}
                                        onItemCollected = {this.handleItemCollected}
                                        onFileChanged = {this.handleFileChange}
                                        onInputChanged = {this.handleInputChange}>
                    </ShoppingList>
                    <button type="button" className="addNewButton" onClick={this.handleNewItem}>Add New Item</button>
                    <ShoppingListTotal items={this.state.filteredItems}></ShoppingListTotal>
                </form>
            );
        }
        
    }
}

export default ShoppingListForm