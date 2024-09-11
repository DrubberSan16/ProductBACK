import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './pages/Home';
import WishlistPage from './pages/WishlistPage';

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/wishlist" element={<WishlistPage />} />
            </Routes>
        </Router>
    );
};

export default App;
