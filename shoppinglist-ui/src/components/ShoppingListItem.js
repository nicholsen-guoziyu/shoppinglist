import React, { Component } from "react";

class ShoppingListItem extends Component
{
    constructor(props)
    {
        super(props);
        this.handleSaveClick = this.handleSaveClick.bind(this);
        this.handleDeleteClick = this.handleDeleteClick.bind(this);
    }

    handleSaveClick(event, index)
    {
        if(this.props[index].itemId == 0)
        {
            //call the API to create new item in the server. the server will return the new id and image name
            this.props.addItem(event, index, itemId, itemImageName);
        }
        else
        {
            //call the API to update item if there is any new image uploaded, the server will return imageName
            this.props.updateImage(event, index, imageName);

        }
    }

    handleDeleteClick(event, index)
    {
        //call the API to delete the item
        this.props.deleteItem(event, index);
    }

    handleItemCollected(event, index)
    {
        //call the API to update the item status to Collected
        this.props.collectItem(event, index);
    }

    render()
    {
        return
        (
            props.items.map((val, idx) => 
            {
                let storeId = "store-${idx}";
                let itemName =  "itemName-${idx}";
                let itemBrand = "itemBrand-${idx}";
                let itemQuantity = "itemQuantity-${idx}";
                let itemPrice = "itemPrice-${idx}";
                let itemPriority = "itemPriority-${idx}";
                let itemStatus = "itemStatus-${idx}";
                let itemRemark = "itemRemark-${idx}";
                let itemImageName = "itemImageName-${idx}";
                return
                (
                    <div class="ShoppingListItem">
                        <input class="ShoppingListItemCheckbox" type="checkbox" />
                        <button type="button" class="item item-header collapsible">prop.items[idx].itemName</button>
                        <div class="ShoppingListItemDetail collapsible-item hide">
                            <label class="item" for="File1">Upload File </label><input class="item" type="file" id="File1" name="File1" />
                            <label class="item" for={store}>Store </label><input class="item" type="text" id={store} name={store} value={this.props.items[idx].store} onchange={this.props.handleInputChange} data-id={idx} />
                            <label class="item" for={itemName}>Name </label><input class="item" type="text" id={itemName} name={itemName} value={this.props.items[idx].itemName} onchange={this.props.handleInputChange} data-id={idx} />
                            <label class="item" for={itemBrand}>Brand </label><input class="item" type="text" id={itemBrand} name={itemBrand} value={this.props.items[idx].itemBrand} onchange={this.props.handleInputChange} data-id={idx} />
                            <label class="item" for={itemQuantity}>Quantity </label><input class="item" type="text" id={itemQuantity} name={itemQuantity} value={this.props.items[idx].itemQuantity} onchange={this.props.handleInputChange} data-id={idx} />
                            <label class="item" for={itemPrice}>Price </label><input class="item" type="text" id={itemPrice} name={itemPrice} value={this.props.items[idx].itemPrice} onchange={this.props.handleInputChange} data-id={idx} />
                            <label class="item" for={itemPriority}>Priority </label><select class="item" id={itemPriority} name={itemPriority} value={this.props.items[idx].itemPriority} onchange={this.props.handleInputChange} data-id={idx}>
                                <option value="1">1</option>
                                <option value="2">2</option>
                                <option value="3">3</option>
                                <option value="4">4</option>
                            </select>
                            <label class="item" for={itemStatus}>Status </label><select class="item" id={itemStatus} name={itemStatus} value={this.props.items[idx].itemStatus} onchange={this.props.handleInputChange} data-id={idx}>
                                <option value="New">New</option>
                                <option value="Collected">Collected</option>
                                <option value="Out of Stock">Out of Stock</option>
                                <option value="Paid">Paid</option>
                            </select>
                            <label class="item" for={itemRemark}>Remark </label><textarea class="item" rows="10" cols="30" id={itemRemark} name={itemRemark} value={this.props.items[idx].itemRemark} onchange={this.props.handleInputChange} data-id={idx}></textarea>
                            <img class="item-image" id={itemImageName} src={props.items[idx].imageName} />
                            <div class="ShoppingListItemAction">
                                <button type="submit" onClick={this.handleSaveClick.bind(this, idx, this.props[idx].itemId)}>Save</button>
                                <button type="submit">Delete</button>
                            </div>
                        </div>
                    </div>
                );
            })
            
        );
    }
}