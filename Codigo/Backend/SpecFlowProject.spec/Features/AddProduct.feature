Feature: AgregarProducto
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowProject.spec/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Ingreso de codigo, nombre, descripcion y precio válidos.
	Given que ingreso "codigo", "nombre", "descripcion" y "precio"
	When hago click en el botón agregar
	Then el producto se agrega a la lista de productos

Scenario: Ingreso de nombre, descripcion, precio válidos y codigo invalido.
	Given que ingreso "codigo", "nombre", "descripcion" y "precio"
	When hago click en el botón agregar
	Then salta un mensaje de error con codigo invalido y el producto no se agrega a la lista
	

Scenario: Ingreso de codigo, descripcion, precio válidos y nombre invalido.
	Given que ingreso "codigo", "nombre", "descripcion" y "precio"
	When hago click en el botón agregar
	Then salta un mensaje de error con nombre invalido y el producto no se agrega a la lista

Scenario: Ingreso de codigo, nombre, precio válidos y descripcion invalida.
	Given que ingreso "codigo", "nombre", "descripcion" y "precio"
	When hago click en el botón agregar
	Then salta un mensaje de error con descripcion invalida y el producto no se agrega a la lista


Examples:
| description        | name     | code  | price |
| new shaker         | product1 | 59595 | 200   |
| new excercise ball | product2 | 123456 | 300   |
| new excercise ball | product3 | 12345 | 300   |
| new excercise ball | product4 | 12345 | 300   |