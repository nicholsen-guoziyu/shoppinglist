import React, { Component } from "react";
import { ShoppingItemApiUrl } from '../constants/ApiUrl';
class ShoppingList extends Component
{
    constructor(props)
    {
        super(props);
        this.handleSaveClick = this.handleSaveClick.bind(this);
        this.handleDeleteClick = this.handleDeleteClick.bind(this);
        this.handleItemCollected = this.handleItemCollected.bind(this);
        this.handleCollapsible = this.handleCollapsible.bind(this);
        this.handleFileChange = this.handleFileChange.bind(this);
    }

    handleSaveClick(event)
    {
        event.preventDefault();
        let formData = new FormData();
        formData.append('shoppingId', this.props.shoppingId);
        formData.append('store', this.props.items[event.target.dataset.internalindex].store);
        formData.append('itemName', this.props.items[event.target.dataset.internalindex].itemName);
        formData.append('itemBrand', this.props.items[event.target.dataset.internalindex].itemBrand);
        formData.append('itemQuantity', this.props.items[event.target.dataset.internalindex].itemQuantity);
        formData.append('itemPrice', this.props.items[event.target.dataset.internalindex].itemPrice);
        formData.append('itemPriority', this.props.items[event.target.dataset.internalindex].itemPriority);
        formData.append('itemStatus', this.props.items[event.target.dataset.internalindex].itemStatus);
        formData.append('itemRemark', this.props.items[event.target.dataset.internalindex].itemRemark);
        formData.append('imageName', this.props.items[event.target.dataset.internalindex].imageName);
        formData.append('imageFile', this.props.items[event.target.dataset.internalindex].selectedFile);
        event.persist(); // tell React to no make the event as null in the fetch callback
        if(this.props.items[event.target.dataset.internalindex].id === 0)
        {
            fetch(`${ShoppingItemApiUrl}`, 
            {
                method: 'POST',
                body:formData
            })
            .then(res => res.json())
            .then(shoppingItemResponse => {
                this.props.onItemAdded(event, shoppingItemResponse.shoppingItemId, shoppingItemResponse.shoppingItemImageUrl);
            })
            .catch(
                err => console.log(err)
            );
        }
        else
        {
            formData.append('id', this.props.items[event.target.dataset.internalindex].id);
            fetch(`${ShoppingItemApiUrl}`, 
            {
                method: 'PUT',
                body:formData
            })
            .then(res => res.json())
            .then(shoppingItemResponse => {
                if(this.props.items[event.target.dataset.internalindex].selectedFile != null)
                {
                    this.props.onImageUpdated(event, shoppingItemResponse.shoppingItemImageUrl);
                }
            })
            .catch(
                err => console.log(err)
            );
        }
    }

    handleDeleteClick(event)
    {
        event.preventDefault();
        let confirmDeletion = window.confirm('Do you really wish to delete it?');
        if (confirmDeletion) {
            if(this.props.items[event.target.dataset.internalindex].id > 0)
            {
                event.persist();
                fetch(`${ShoppingItemApiUrl}/${this.props.items[event.target.dataset.internalindex].id}`, {
                    method: 'delete',
                    headers: {
                    'Content-Type': 'application/json'
                    }
                })
                .then(res => {
                    this.props.onItemDeleted(event);
                })
                .catch(err => console.log(err));
            }
            else
            {
                this.props.onItemDeleted(event);
            }
        }
    }
    
    handleItemCollected(event)
    {
        event.preventDefault();
        //call the API to update the item status to Collected
        this.props.onItemCollected(event);
    }

    handleCollapsible(event)
    {
        event.target.classList.toggle("inactive");
        let nextElement = event.target.nextElementSibling;
        if (nextElement.classList.contains("hide")) {
            nextElement.classList.remove("hide");
        }
        else {
            nextElement.classList.add("hide");
        }
    }

    handleFileChange(event)
    {
        this.props.onFileChanged(event);
    }

    render()
    {
        return (
            <div className="ShoppingList">
            {
                this.props.items.map((item, idx) => 
                {
                    const selectedFile = `selectedFile-${idx}`;
                    const store = `store-${idx}`;
                    const itemName =  `itemName-${idx}`;
                    const itemBrand = `itemBrand-${idx}`;
                    const itemQuantity = `itemQuantity-${idx}`;
                    const itemPrice = `itemPrice-${idx}`;
                    const itemPriority = `itemPriority-${idx}`;
                    const itemStatus = `itemStatus-${idx}`;
                    const itemRemark = `itemRemark-${idx}`;
                    const itemImageName = `itemImageName-${idx}`;
                    let image;
                    if(this.props.items[idx].itemImageUrlList != null && this.props.items[idx].itemImageUrlList.length > 0)
                    {
                        if(this.props.items[idx].itemImageUrlList[this.props.items[idx].itemImageUrlList.length - 1] != null)
                        {
                            image = <img className="item-image" id={itemImageName} src={this.props.items[idx].itemImageUrlList[this.props.items[idx].itemImageUrlList.length - 1]} alt="Item" />
                        }
                    }
                    return(
                        <div className="ShoppingListItem" key={idx}>
                            <input className="ShoppingListItemCheckbox" type="checkbox" onClick={this.handleItemCollected} data-index={item.index} data-internalindex={idx}/>
                            <button type="button" className="item item-header collapsible" onClick={this.handleCollapsible}>{item.itemName}</button>
                            <div className="ShoppingListItemDetail collapsible-item">
                                <label className="item" for={selectedFile}>Upload File </label><input className="item" type="file" id={selectedFile} name={selectedFile} onChange={this.handleFileChange}  data-index={item.index} data-internalindex={idx} data-name="selectedFile" />
                                <label className="item" for={store}>Store </label><input className="item" type="text" id={store} name={store} value={this.props.items[idx].store} onChange={this.props.onInputChanged}  data-index={item.index} data-internalindex={idx} data-name="store" />
                                <label className="item" for={itemName}>Name </label><input className="item" type="text" id={itemName} name={itemName} value={this.props.items[idx].itemName} onChange={this.props.onInputChanged}  data-index={item.index} data-internalindex={idx} data-name="itemName" />
                                <label className="item" for={itemBrand}>Brand </label><input className="item" type="text" id={itemBrand} name={itemBrand} value={this.props.items[idx].itemBrand} onChange={this.props.onInputChanged}  data-index={item.index} data-internalindex={idx}  data-name="itemBrand" />
                                <label className="item" for={itemQuantity}>Quantity </label><input className="item" type="text" id={itemQuantity} name={itemQuantity} value={this.props.items[idx].itemQuantity} onChange={this.props.onInputChanged}  data-index={item.index} data-internalindex={idx} data-name="itemQuantity" />
                                <label className="item" for={itemPrice}>Price </label><input className="item" type="text" id={itemPrice} name={itemPrice} value={this.props.items[idx].itemPrice} onChange={this.props.onInputChanged}  data-index={item.index} data-internalindex={idx} data-name="itemPrice" />
                                <label className="item" for={itemPriority}>Priority </label><select className="item" id={itemPriority} name={itemPriority} value={this.props.items[idx].itemPriority} onChange={this.props.onInputChanged}  data-index={item.index} data-internalindex={idx} data-name="itemPriority">
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                </select>
                                <label className="item" for={itemStatus}>Status </label><select className="item" id={itemStatus} name={itemStatus} value={this.props.items[idx].itemStatus} onChange={this.props.onInputChanged}  data-index={item.index} data-internalindex={idx} data-name="itemStatus">
                                    <option value="1">New</option>
                                    <option value="2">Collected</option>
                                    <option value="3">Out of Stock</option>
                                    <option value="4">Paid</option>
                                </select>
                                <label className="item" for={itemRemark}>Remark </label><textarea className="item" rows="10" cols="30" id={itemRemark} name={itemRemark} value={this.props.items[idx].itemRemark} onChange={this.props.onInputChanged}  data-index={item.index} data-internalindex={idx} data-name="itemRemark"></textarea>
                                {image}
                                <div className="ShoppingListItemAction">
                                    <button type="submit" onClick={this.handleSaveClick} data-index={item.index} data-internalindex={idx}>Save</button>
                                    <button type="submit" onClick={this.handleDeleteClick} data-index={item.index} data-internalindex={idx}>Delete</button>
                                </div>
                            </div>
                        </div>
                    )
                })
            }
            </div>
        )
    }
}

export default ShoppingList;