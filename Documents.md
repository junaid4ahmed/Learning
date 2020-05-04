## Project Structure
- Learning.Model
- Learning.DataAccess
- Learning.Reporting
- Learning.ConsoleApp

## Category
- Learning.Model.Category provides model object 
- Learning.Model.Configuration.Category provide configuration for model category for entity framework
- Learning.DataAccess.Category provides basic operations for select, insert, update and delete of category
## Supplier
## Product
## Account

## Purchase
### creating purchase and adding it to inventory and post it to leger
- create purchase, newly created purchase will have status "New"
- edit purchase items in it such as insert, update and delete as required
- submit for approval 
- approved purchase is not allowed to perform any changes to its purchase items like insert, update and delete 
- approved purchase is now ready for its purchase items to be received or insert, update and delete to inventory
- after all purchase items have been received or inserted to inventory the purchase will have "Receive" status and no longer be able to change purchase items in inventory
- received purchase is now ready to be posted and payed
#### working purchase items in inventory
- Learning.DataAccess.Inventory class provides methods, once purchase is approved, for editing purchase items in inventory
#### working with purchase in post aka leger
- Learning.DataAccess.Post class provides methods, once purchase is fully received, for editing pruchase in post aka leger
