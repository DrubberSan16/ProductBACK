import React, { useState, useEffect } from 'react';
import axios from 'axios';

const WishlistPage = () => {
  const [wishlist, setWishlist] = useState([]);

  useEffect(() => {
    fetchWishlist();
  }, []);

  const fetchWishlist = async () => {
    try {
      const response = await axios.get('https://localhost:5000/api/wishlist');
      setWishlist(response.data);
    } catch (error) {
      console.error('Error fetching wishlist:', error);
    }
  };

  const removeFromWishlist = async (productId) => {
    try {
      await axios.delete(`https://localhost:5000/api/wishlist/${productId}`);
      setWishlist(wishlist.filter((item) => item.id !== productId));
    } catch (error) {
      console.error('Error removing from wishlist:', error);
    }
  };

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">Productos Deseados</h1>
      {wishlist.length === 0 ? (
        <p>No hay productos en tu lista de deseos.</p>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          {wishlist.map((product) => (
            <div key={product.id} className="border p-4 rounded">
              <h2 className="text-xl font-bold">{product.name}</h2>
              <p>{product.description}</p>
              <p className="text-green-600">${product.price}</p>
              <button
                onClick={() => removeFromWishlist(product.id)}
                className="mt-2 p-2 bg-red-500 text-white rounded"
              >
                Eliminar de Deseados
              </button>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default WishlistPage;
