import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import PictureList from './components/pictureList';
import PictureDetail from './components/pictureDetail';
import PictureForm from './components/pictureForm';

const App = () => {
    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path="/" element={<PictureList />} />
                    <Route path="/pictures/:id" element={<PictureDetail />} />
                    <Route path="/add" element={<PictureForm />} />
                    <Route path="/edit/:id" element={<PictureForm />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;
