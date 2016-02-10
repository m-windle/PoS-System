# PoS-System

Pulls data from the database to populate the product list. The user is able to select which user is creating the transaction and add new quantities to products on this screen.
The user dropdown list is also populated from the employees table. Upon clicking "Start New Transaction", the user is brought to the transaction screen.

![Main Screen](https://raw.github.com/m-windle/PoS-System/blob/master/main.PNG)

On the transaction screen, the user is able to select which products to add to the transaction, the quantity of the products, and any applicable discounts.
The product, quantity, discounts, and total are added to the current transaction upon clicking "Process Transaction". 
When the user is done adding products, the "Complete Transaction" button stores the transaction in the database for future reference
and the necessary quanitities are reduced from the current inventory. 
Users will be notified and not allowed to add more product than is currently in the inventory. 

![Transaction Screen](https://raw.github.com/m-windle/PoS-System/blob/master/transaction.PNG)
