import axios from 'axios';

const API_URL = '/api/Pictures'; 

export const getPictures = async () => {
    const response = await axios.get(API_URL);
    return response.data;
};

export const getPicture = async (id) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
};

export const createPicture = async (picture) => {
    const response = await axios.post(API_URL, picture);
    return response.data;
};

export const updatePicture = async (id, picture) => {
    const response = await axios.put(`${API_URL}/${id}`, picture);
    return response.data;
};

export const deletePicture = async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
};
