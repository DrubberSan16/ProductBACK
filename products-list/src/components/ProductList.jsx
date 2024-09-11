import React, { useEffect, useState } from 'react';
import { getProducts } from '../api/productService';

const ProductList = () => {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        async function fetchData() {
            const data = await getProducts();
            setProducts(data);
        }
        fetchData();
    }, []);

    return (
        <div className="product-list">
            {products.map(product => (
                <div key={product.id} className="product-item">
                    <h2>{product.name}</h2>
                    <p>{product.price}</p>
                    <button>Ver Detalles</button>
                </div>
            ))}
        </div>
    );
};

export default ProductList;
