import { Component, OnInit } from '@angular/core';
import { cilBarcode, cilPencil, cilPaint, cilAlignCenter, cilDollar, cilLibrary, cilLoop1, cilTask, cilShortText } from '@coreui/icons';
import { AbstractControl, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Pharmacy } from '../../../interfaces/pharmacy';
import { ProductService } from 'src/app/services/productService';
import { ProductRequest } from 'src/app/interfaces/product';
import { CommonService } from '../../../services/CommonService';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css'],
})

export class CreateProductComponent implements OnInit {
  form: FormGroup | any;
  pharmacys: Pharmacy[] = [];

  icons = { cilBarcode, cilPencil, cilAlignCenter, cilLibrary,
    cilDollar, cilLoop1, cilTask, cilShortText, cilPaint };

  constructor(
    private commonService: CommonService,
    private productService: ProductService,
    private fb: FormBuilder
  ) {
    
    this.form = this.fb.group({
        name: new FormControl(),
        code: new FormControl(),
        description: new FormControl(), 
        prize: new FormControl(),
      });
  }

  ngOnInit(): void {

  }

  get name(): AbstractControl {
    return this.form.controls.name;
  }

  get code(): AbstractControl {
    return this.form.controls.code;
  }

  get description(): AbstractControl {
    return this.form.controls.description;
  }

  get prize(): AbstractControl {
    return this.form.controls.prize;
  }

  createProduct(): void {
    let name = this.name.value ? this.name.value : "";
    let code = this.code.value ? this.code.value : "";
    let description = this.description.value ? this.description.value : "";
    let prize = this.prize.value ? this.prize.value : 0;

    let productRequest = new ProductRequest(name, code, description, prize);
        this.productService.createProduct(productRequest).subscribe((product) => {
        this.form.reset();

        if (product){
          this.commonService.updateToastData(
            `Success creating "${product.code} - ${product.name}"`,
            'success',
            'Drug created.'
          );
        }
      });

  }
}
