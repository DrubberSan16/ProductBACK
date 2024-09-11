import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Home = () => {
  const [products, setProducts] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [wishlist, setWishlist] = useState([]);

  useEffect(() => {
    fetchProducts();
  }, []);

  const fetchProducts = async () => {
    try {
      const response = await axios.get('https://localhost:7144/api/Products');
      setProducts(response.data);
    } catch (error) {
      console.error('Error fetching products:', error);
    }
  };

  const handleSearch = async () => {
    try {
      const response = await axios.get(`https://localhost:7144/api/Products/search?search=${searchTerm}`);
      setProducts(response.data);
    } catch (error) {
      console.error('Error searching products:', error);
    }
  };

  const addToWishlist = async (product) => {
    try {
      await axios.post('https://localhost:7144/api/wishlist', { productId: product.id });
      setWishlist([...wishlist, product]);
    } catch (error) {
      console.error('Error adding to wishlist:', error);
    }
  };

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">Buscar Productos</h1>
      <div className="mb-4">
        <input
          type="text"
          className="p-2 border rounded"
          placeholder="Buscar producto..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <button onClick={handleSearch} className="ml-2 p-2 bg-blue-500 text-white rounded">
          Buscar
        </button>
      </div>
      <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
        {products.map((product) => (
          <div key={product.id} className="border p-4 rounded">
            <h2 className="text-xl font-bold">{product.nameProduct}</h2>
            <p>{product.description}</p>
            <p className="text-green-600">${product.precUnit}</p>
            <button
              onClick={() => addToWishlist(product)}
              className="mt-2 p-2 bg-green-500 text-white rounded"
            >
              Agregar a Deseados
            </button>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Home;
