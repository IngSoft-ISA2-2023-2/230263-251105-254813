Feature: AgregarProducto
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowProject.spec/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Ingreso de codigo, nombre, descripcion y precio válidos.
	Given que ingreso "codigo", "nombre", "descripcion" y "precio" correctamente
	And  deseo dar de alta un "producto", como "empleado"
	When hago click en el botón agregar
	Then el producto se agrega a la lista de productos

Scenario: Ingreso de nombre, descripcion, precio válidos y codigo invalido.
	Given Dado que ingreso "codigo" de 6 digitos e ingreso "nombre", "descripcion" y "precio" correctamente
	When hago click en el botón agregar
	Then salta un mensaje de error
	And el producto no se agrega a la lista

Scenario: Ingreso de codigo, descripcion, precio válidos y nombre invalido.
	Given que ingreso "nombre" de 31 digitos
	And ingreso "codigo", "descripcion" y "precio" correctamente
	When hago click en el botón agregar
	Then salta un mensaje de error
	And el producto no se agrega a la lista

Scenario: Ingreso de codigo, nombre, precio válidos y descripcion invalida.
	Given que ingreso "descripcion" de 71 digitos
	And ingreso "codigo", "nombre" y "precio" correctamente
	When hago click en el botón agregar
	Then salta un mensaje de error
	And el producto no se agrega a la lista