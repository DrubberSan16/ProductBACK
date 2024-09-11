import React, { useEffect, useState } from 'react';
import { getWishlist, removeProductFromWishlist } from '../api/productService';

const Wishlist = () => {
    const [wishlist, setWishlist] = useState([]);

    useEffect(() => {
        async function fetchWishlist() {
            const data = await getWishlist();
            setWishlist(data);
        }
        fetchWishlist();
    }, []);

    const handleRemoveFromWishlist = async (productId) => {
        await removeProductFromWishlist(productId);
        setWishlist(wishlist.filter(product => product.id !== productId));
    };

    return (
        <div className="wishlist">
            <h2>Mis Productos Deseados</h2>
            {wishlist.map(product => (
                <div key={product.id}>
                    <p>{product.name}</p>
                    <button onClick={() => handleRemoveFromWishlist(product.id)}>Eliminar</button>
                </div>
            ))}
        </div>
    );
};

export default Wishlist;
