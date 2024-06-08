import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { getPictures, deletePicture } from '../services/pictureService';

const PictureList = () => {
    const [pictures, setPictures] = useState([]);

    useEffect(() => {
        fetchPictures();
    }, []);

    const fetchPictures = async () => {
        const data = await getPictures();
        setPictures(data);
    };

    const handleDelete = async (id) => {
        await deletePicture(id);
        fetchPictures();
    };

    return (
        <div>
            <h1>Picture List</h1>
            <Link to="/add">Add Picture</Link>
            <ul>
                {pictures.map(picture => (
                    <li key={picture.id}>
                        <Link to={`/pictures/${picture.id}`}>{picture.name}</Link>
                        <button onClick={() => handleDelete(picture.id)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default PictureList;
