import React, { Component } from "react";

class ShoppingListItem extends Component
{
    constructor(props)
    {
        super(props);
        this.handleSaveClick = this.handleSaveClick.bind(this);
        this.handleDeleteClick = this.handleDeleteClick.bind(this);
        this.handleItemCollected = this.handleItemCollected.bind(this);
        this.handleCollapsible = this.handleCollapsible.bind(this);
    }

    handleSaveClick(event)
    {
        if(this.props[event.target.dataset.internalIndex].itemId == 0)
        {
            //call the API to create new item in the server. the server will return the new id and image name
            let itemId = 0;
            let itemImageName = "";
            this.props.onItemAdded(event, itemId, itemImageName);
        }
        else
        {
            //call the API to update item if there is any new image uploaded, the server will return imageName
            let itemImageName = "";
            if(this.props[event.target.dataset.internalIndex].selectedFile != null)
            {
                this.props.onImageUpdated(event, imageName);
            }
        }
    }

    handleDeleteClick(event)
    {
        if(this.props[event.target.dataset.internalIndex].itemId > 0)
        {
            //call the API to delete the item
        }
        this.props.onItemDeleted(event);
    }

    handleItemCollected(event)
    {
        //call the API to update the item status to Collected
        this.props.onItemCollected(event);
    }

    handleCollapsible(event)
    {
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
            <div class="ShoppingList">
            {
                props.items.map((item, idx) => 
                {
                    let selectedFile = "selectedFile-${idx}";
                    let storeId = "store-${idx}";
                    let itemName =  "itemName-${idx}";
                    let itemBrand = "itemBrand-${idx}";
                    let itemQuantity = "itemQuantity-${idx}";
                    let itemPrice = "itemPrice-${idx}";
                    let itemPriority = "itemPriority-${idx}";
                    let itemStatus = "itemStatus-${idx}";
                    let itemRemark = "itemRemark-${idx}";
                    let itemImageName = "itemImageName-${idx}";
                    return(
                        <div class="ShoppingListItem">
                            <input class="ShoppingListItemCheckbox" type="checkbox" onClick={this.handleItemCollected} data-index={item.index} data-internalIndex={idx}/>
                            <button type="button" class="item item-header collapsible" onClick={this.handleCollapsible}>prop.items[idx].itemName</button>
                            <div class="ShoppingListItemDetail collapsible-item hide">
                                <label class="item" for={selectedFile}>Upload File </label><input class="item" type="file" id={selectedFile} name={selectedFile} onchange={this.handleFileChange}  data-index={item.index} data-internalIndex={idx} data-name="selectedFile" />
                                <label class="item" for={store}>Store </label><input class="item" type="text" id={store} name={store} value={this.props.items[idx].store} onchange={this.props.onInputChanged}  data-index={item.index} data-internalIndex={idx} data-name="store" />
                                <label class="item" for={itemName}>Name </label><input class="item" type="text" id={itemName} name={itemName} value={this.props.items[idx].itemName} onchange={this.props.onInputChanged}  data-index={item.index} data-internalIndex={idx} data-name="itemName" />
                                <label class="item" for={itemBrand}>Brand </label><input class="item" type="text" id={itemBrand} name={itemBrand} value={this.props.items[idx].itemBrand} onchange={this.props.onInputChanged}  data-index={item.index} data-internalIndex={idx}  data-name="itemBrand" />
                                <label class="item" for={itemQuantity}>Quantity </label><input class="item" type="text" id={itemQuantity} name={itemQuantity} value={this.props.items[idx].itemQuantity} onchange={this.props.onInputChanged}  data-index={item.index} data-internalIndex={idx} data-name="itemQuantity" />
                                <label class="item" for={itemPrice}>Price </label><input class="item" type="text" id={itemPrice} name={itemPrice} value={this.props.items[idx].itemPrice} onchange={this.props.onInputChanged}  data-index={item.index} data-internalIndex={idx} data-name="itemPrice" />
                                <label class="item" for={itemPriority}>Priority </label><select class="item" id={itemPriority} name={itemPriority} value={this.props.items[idx].itemPriority} onchange={this.props.onInputChanged}  data-index={item.index} data-internalIndex={idx} data-name="itemPriority">
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                </select>
                                <label class="item" for={itemStatus}>Status </label><select class="item" id={itemStatus} name={itemStatus} value={this.props.items[idx].itemStatus} onchange={this.props.onInputChanged}  data-index={item.index} data-internalIndex={idx} data-name="itemStatus">
                                    <option value="1">New</option>
                                    <option value="2">Collected</option>
                                    <option value="3">Out of Stock</option>
                                    <option value="4">Paid</option>
                                </select>
                                <label class="item" for={itemRemark}>Remark </label><textarea class="item" rows="10" cols="30" id={itemRemark} name={itemRemark} value={this.props.items[idx].itemRemark} onchange={this.props.onInputChanged}  data-index={item.index} data-internalIndex={idx} data-name="itemRemark"></textarea>
                                <img class="item-image" id={itemImageName} src={props.items[idx].itemImageName} />
                                <div class="ShoppingListItemAction">
                                    <button type="submit" onClick={this.handleSaveClick} data-index={item.index} data-internalIndex={idx}>Save</button>
                                    <button type="submit" onClick={this.handleDeleteClick} data-index={item.index} data-internalIndex={idx}>Delete</button>
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

export default ShoppingListItem;