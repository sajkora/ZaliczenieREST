import React, { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import { getPicture } from '../services/pictureService';

const PictureDetail = () => {
    const { id } = useParams();
    const [picture, setPicture] = useState(null);

    useEffect(() => {
        fetchPicture();
    }, [id]);

    const fetchPicture = async () => {
        const data = await getPicture(id);
        setPicture(data);
    };

    if (!picture) return <div>Loading...</div>;

    return (
        <div>
            <h1>{picture.name}</h1>
            <img src={`data:image/jpeg;base64,${picture.imageData}`} alt={picture.name} />
            <p>Link: {picture.link}</p>
            <Link to={`/edit/${picture.id}`}>Edit</Link>
            <Link to="/">Back to List</Link>
        </div>
    );
};

export default PictureDetail;
