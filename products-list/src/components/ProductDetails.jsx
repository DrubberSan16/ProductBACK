import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getProductDetails, addProductToWishlist } from '../api/productService';

const ProductDetails = () => {
    const { id } = useParams();
    const [product, setProduct] = useState(null);

    useEffect(() => {
        async function fetchProductDetails() {
            const data = await getProductDetails(id);
            setProduct(data);
        }
        fetchProductDetails();
    }, [id]);

    const handleAddToWishlist = async () => {
        await addProductToWishlist(id);
        alert('Producto agregado a tu lista de deseos');
    };

    return (
        product ? (
            <div className="product-details">
                <h1>{product.name}</h1>
                <p>{product.description}</p>
                <button onClick={handleAddToWishlist}>Agregar a Deseados</button>
            </div>
        ) : (
            <p>Cargando...</p>
        )
    );
};

export default ProductDetails;
