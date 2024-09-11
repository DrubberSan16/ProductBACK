import axios from 'axios';

const API_BASE_URL = 'https://localhost:7144/api'; // Cambia la URL al endpoint de tu API

// Obtener listado de categorías de productos
export const getCategories = async () => {
    const response = await axios.get(`${API_BASE_URL}/categories`);
    return response.data;
};

// Obtener listado de productos
export const getProducts = async () => {
    const response = await axios.get(`${API_BASE_URL}/products`);
    return response.data;
};

// Obtener detalle de un producto
export const getProductDetails = async (productId) => {
    const response = await axios.get(`${API_BASE_URL}/products/${productId}`);
    return response.data;
};

// Agregar un producto como "producto deseado"
export const addProductToWishlist = async (productId) => {
    const response = await axios.post(`${API_BASE_URL}/wishlist`, { productId });
    return response.data;
};

// Eliminar un producto deseado
export const removeProductFromWishlist = async (productId) => {
    const response = await axios.delete(`${API_BASE_URL}/wishlist/${productId}`);
    return response.data;
};

// Consultar listado de productos deseados de un usuario
export const getWishlist = async () => {
    const response = await axios.get(`${API_BASE_URL}/wishlist`);
    return response.data;
};
