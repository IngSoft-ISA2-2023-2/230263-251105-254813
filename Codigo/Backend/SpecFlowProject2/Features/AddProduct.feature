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
	Then salta un mensaje de error con datos invalidos y el producto no se agrega a la lista
Examples:
	| codigo | nombre                          | descripcion       | precio |
	| 123497 | desodorante                     | Es para el cuerpo | 300    |
	| 123470 | desodorante                     | es para el cuerpo | 308    |

Scenario: Nombre mayor a treinta caracteres
	Given ingresamos el nombre <nombre> del producto
	And ingresamos la descripcion <descripcion> del producto
	And ingresamos el codigo <codigo> del producto
	And ingresamos el precio <precio> del producto
	When hago click en el botón agregar
	Then salta un mensaje de error con datos invalidos y el producto no se agrega a la lista
Examples:
	| codigo | nombre									| descripcion       | precio |
	| 67890  | aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa      | Es para el cuerpo | 300    |
	| 88888  | ooooooooooooooooooooooooooooooooooo      | es para el cuerpo | 308    |

Scenario: Descripcion mayor a setenta caracteres
	Given ingresamos el nombre <nombre> del producto
	And ingresamos la descripcion <descripcion> del producto
	And ingresamos el codigo <codigo> del producto
	And ingresamos el precio <precio> del producto
	When hago click en el botón agregar
	Then salta un mensaje de error con datos invalidos y el producto no se agrega a la lista
Examples:
	| codigo | nombre	| descripcion																	  | precio |
	| 67890  | nombre 1	| La aventura comienza cuando menos lo esperas y te sorprende de la mejor manera. | 300    |


Scenario: Ingreso de codigo, nombre, precio válidos y descripcion valido.
	Given ingresamos el nombre <nombre> del producto
	And ingresamos la descripcion <descripcion> del producto
	And ingresamos el codigo <codigo> del producto
	And ingresamos el precio <precio> del producto
	When hago click en el botón agregar
	Then agrega el producto a la farmacia


Examples:
	| codigo | nombre                         | descripcion       | precio |
	| 12390  | desodorante                    | Es para el cuerpo | 300    |
	| 12391  | desodorante                    | es para el cuerpo | 308    |