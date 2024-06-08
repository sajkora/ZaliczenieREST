import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { createPicture, getPicture, updatePicture } from '../services/pictureService';

const PictureForm = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [picture, setPicture] = useState({ name: '', imageData: null });

    useEffect(() => {
        if (id) {
            fetchPicture();
        }
    }, [id]);

    const fetchPicture = async () => {
        const data = await getPicture(id);
        setPicture(data);
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setPicture((prevState) => ({
            ...prevState,
            [name]: value,
        }));
    };

    const handleFileChange = (e) => {
        setPicture((prevState) => ({
            ...prevState,
            imageData: e.target.files[0],
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const formData = new FormData();
        formData.append('name', picture.name);
        formData.append('imageFile', picture.imageData);

        if (id) {
            await updatePicture(id, formData);
        } else {
            await createPicture(formData);
        }
        navigate('/');
    };

    return (
        <div>
            <h1>{id ? 'Edit' : 'Add'} Picture</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Name</label>
                    <input type="text" name="name" value={picture.name} onChange={handleChange} />
                </div>
                <div>
                    <label>Image</label>
                    <input type="file" name="imageData" onChange={handleFileChange} />
                </div>
                <button type="submit">Save</button>
            </form>
        </div>
    );
};

export default PictureForm;
