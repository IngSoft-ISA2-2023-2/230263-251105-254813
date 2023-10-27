Feature: ModifyProduct

A short summary of the feature

@tag1
Scenario: Modificar producto con datos validos
	Given ingresamos el nombre <nombre> del producto a modificar 
	And ingresamos la descripcion <descripcion> del producto a modificar
	And ingresamos el codigo <codigo> del producto a modificar
	And ingresamos el precio <precio> del producto a modificar
	When hago click en el botón modificar
	Then se modifica exitosamente

Examples:
	| codigo | nombre                          | descripcion       | precio |
	| 23457  | desodorante1                    | Es para el cuerpo2 | 303    |
