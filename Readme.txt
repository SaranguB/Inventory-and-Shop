Overview

This Shop System is designed using the MVC (Model-View-Controller) pattern in Unity to provide a structured and maintainable approach to handling shop-related functionalities. The system allows players to buy and sell items, manage inventory, and update player resources dynamically.

Features

Item Buying & Selling: Players can purchase items and sell unwanted items for in-game currency.

Inventory Management: Updates item quantities and removes items when they reach zero quantity.

Event-Driven Architecture: Utilizes Unity's event system for communication between controllers and views.

Dynamic UI Updates: Real-time updates to item quantities, player coins, and inventory UI.

System Architecture

1. Model (ShopModel, InventoryModel, PlayerModel)

Stores item data, player currency, and inventory state.

Uses dictionaries for efficient item lookup and quantity management.

2. View (ShopView, InventoryView, PlayerView)

Handles UI updates, displaying available items, and reflecting changes.

Shows item prices, quantities, and updates the player's coin balance.

3. Controller (ShopController, InventoryController, PlayerController)

Manages player interactions such as purchasing and selling.

Calls model functions to update item quantities and player currency.

Uses event-driven communication for UI updates.

-> Key Functionalities

Buying Items

Retrieves selected item from the shop.

Checks if the player has enough currency.

Updates item quantity and deducts player coins.

Triggers UI update events.

Selling Items

Gets the selected item from inventory.

Deducts the item quantity and adds coins to the player.

If the item quantity reaches zero, removes the item view.

Triggers necessary UI updates using event system.

->Event System

The system uses Unity's event system for communication between different components.

Example Events:

onItemBought(int itemID, int quantity) - Triggered when an item is purchased.

onItemSold(int itemID, int quantity) - Triggered when an item is sold.

onInventoryUpdated() - Updates UI when inventory changes.

Usage Instructions

Attach ShopView, ShopController, and ShopModel to relevant GameObjects.

Assign UI elements (item panels, buttons, text fields) in the inspector.

Ensure EventService is properly initialized for event handling.

Run the game and interact with the shop system.

Conclusion

This Shop System efficiently manages in-game transactions using MVC principles and an event-driven approach, making it scalable and easy to maintain. Future enhancements can improve the player experience and add more functionalities.