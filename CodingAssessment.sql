/* You have three different tables
A Customer Table with FirstName, LastName, Age, Occupation, MartialStatus, PersonID

An Orders Table with OrderID, PersonID, DateCreated, MethodofPurchase

An Orders Details table with OrderID, OrderDetailID, ProductNumber, ProductID, ProductOrigin



Please return a result of the customers who ordered product ID = 1112222333 and return
FirstName and LastName as full name, age, orderid, datecreated, MethodOfPurchase as Purchase Method, ProductNumber and ProductOrigin
*/

SELECT c.FirstName+' '+c.LastName as 'FullName', c.Age, o.OrderID, o.DateCreated, o.MethodOfPurchase  as 'Purchase Method', od.ProductNumber, od.ProductOrigin
FROM Customer c 
INNER JOIN Orders o ON c.PersonID = o.PersonID
INNER JOIN OrdersDetails od ON od.OrderID = o.OrderID
WHERE od.ProductID = 1112222333
