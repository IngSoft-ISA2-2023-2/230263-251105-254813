Feature: CreateProductPurchase

A short summary of the feature

@tag1
Scenario: Crear una compra de producto junto con medicamento
	Given se ingresa el email <email> valido
	And se ingresa la fecha <date> valida
	And se ingresa el codigo <codigoProd> del producto valido
	And se ingresa el id <id> de la farmacia valido
	And se ingresa el codigo <codigo> de la droga valido
	And se ingresa el codigo <codigoProd> del producto valido
	And se ingresa la cantidad <cantidad> de la droga valido 
	And se ingresa la cantidad <cantidadProd> del producto valido
	When hace click en el boton crear compra
	Then se crea el producto de forma correcta 
Examples: 
	| email             | date                     | id | codigo | codigoProd | cantidad | cantidadProd |
	| julieta@gmail.com | 2023-10-28T19:14:50.890Z | 1  | GFR    | 12345      | 3        | 1            |
