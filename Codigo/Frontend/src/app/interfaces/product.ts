export interface Product {
    id: number;
    name: string;
    code: string;
    description: string;
    price: number;
    deleted: boolean;
    pharmacy: {
      id: number;
      name: string;  
    };
}

export class ProductRequest {
    name: string;
    code: string;
    description: string;
    prize: number;

    constructor(name: string, code: string, description: string, prize: number){
        this.name = name;
        this.code = code;
        this.description = description;
        this.prize = prize;
    }
}
