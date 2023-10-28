Feature: DeleteProduct

Narrativa:
Como: empleado de farmacia.
Quiero: poder eliminar un producto existente en el sistema.
Para: modificar el inventario de la farmacia.

@mytag
Scenario: Eliminar un producto existente
	Given estoy logueado como empleado e ingreso un codigo <codigo> de un producto existente
	When hago click en el botón eliminar
	Then el producto se elimina de la lista de productos
Examples:
	| codigo |
	| 12345  |
	| 12347 |

Scenario: Eliminar un producto  que no existe
	Given estoy logueado como empleado e ingreso un codigo <codigo> de un producto existente
	When hago click en el botón eliminar
	Then obtengo un mensaje de error
Examples:
	| codigo |
	| 12345  |
	| 12347  |
