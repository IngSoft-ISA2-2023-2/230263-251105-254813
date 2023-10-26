Feature: InsertProduct

Narrativa:
Como empleado de una farmacia y logeado al sistemo
Quiero agregar un producto a mi farmacia
Para que quede disponible para la venta

@mytag
#Scenario: Insert new product correctly
#	Given ingresamos el nombre <nombre> del producto
#	And ingresamos la descripcion <descripcion> del producto
#	And ingresamos el codigo <codigo> del producto
#	And ingresamos el precio <precio> del producto
#	When hago click en el botón agregar
#	Then agrega el producto a la farmacia
#
#Scenario: Ingreso de nombre, descripcion, precio válidos y codigo invalido.
#	Given ingresamos el nombre <nombre> del producto
#	And ingresamos la descripcion <descripcion> del producto
#	And ingresamos el codigo <codigo> del producto
#	And ingresamos el precio <precio> del producto
#	When hago click en el botón agregar
#	Then salta un mensaje de error con codigo invalido y el producto no se agrega a la lista
#
#Scenario: Ingreso de codigo, descripcion, precio válidos y nombre invalido.
#	Given ingresamos el nombre <nombre> del producto
#	And ingresamos la descripcion <descripcion> del producto
#	And ingresamos el codigo <codigo> del producto
#	And ingresamos el precio <precio> del producto
#	When hago click en el botón agregar
#	Then salta un mensaje de error con nombre invalido y el producto no se agrega a la lista

Scenario: Ingreso de codigo, nombre, precio válidos y descripcion valido.
	Given ingresamos el nombre <nombre> del producto
	And ingresamos la descripcion <descripcion> del producto
	And ingresamos el codigo <codigo> del producto
	And ingresamos el precio <precio> del producto
	When hago click en el botón agregar
	Then agrega el producto a la farmacia
	#Then salta un mensaje de error con descripcion invalida y el producto no se agrega a la lista



Examples:
	| codigo | nombre                         | descripcion       | precio |
	| 12345  | desodorante                    | Es para el cuerpo | 300    |
	| 12347 | desodorante                    | es para el cuerpo | 308    |