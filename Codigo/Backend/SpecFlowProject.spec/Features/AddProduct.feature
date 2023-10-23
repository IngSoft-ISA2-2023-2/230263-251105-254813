Feature: AgregarProducto
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowProject.spec/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Ingreso de codigo, nombre, descripcion y precio válidos.
	Given que ingreso codigo is 12345
	And ingreso nombre is "shampoo"
	And ingreso descripcion is "Limpia el pelo"
	And ingreso precio is 20.00
	When hago click en el botón agregar
	Then muestra el mensaje Agregado


