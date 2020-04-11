import React, {Component} from "react";

class ShoppingListTotal extends Component
{
    constructor(props)
    {
        super(props);
    }

    render()
    {
        return(
            <div class="ShoppingListTotal">
                <label class="item">Total </label>
                <label class="item">$129.00 </label>
            </div>
        )
    }
}