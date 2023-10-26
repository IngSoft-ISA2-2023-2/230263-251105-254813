Feature: InsertProduct

Narrativa:
Como empleado de una farmacia y logeado al sistemo
Quiero agregar un producto a mi farmacia
Para que quede disponible para la venta

@mytag
Scenario: Codigo muy largo
	Given ingresamos el nombre <nombre> del producto
	And ingresamos la descripcion <descripcion> del producto
	And ingresamos el codigo <codigo> del producto
	And ingresamos el precio <precio> del producto
	When hago click en el botón agregar
	Then salta un mensaje de error con codigo invalido y el producto no se agrega a la lista
Examples:
	| codigo | nombre                         | descripcion       | precio |
	| 123497  | desodorante                    | Es para el cuerpo | 300    |
	| 123470 | desodorante                     | es para el cuerpo | 308    |


Scenario: Ingreso de codigo, nombre, precio válidos y descripcion valido.
	Given ingresamos el nombre <nombre> del producto
	And ingresamos la descripcion <descripcion> del producto
	And ingresamos el codigo <codigo> del producto
	And ingresamos el precio <precio> del producto
	When hago click en el botón agregar
	Then agrega el producto a la farmacia


Examples:
	| codigo | nombre                         | descripcion       | precio |
	| 12379  | desodorante                    | Es para el cuerpo | 300    |
	| 12385 | desodorante                    | es para el cuerpo | 308    |