import React, { useState } from 'react';
import './App.css';
import axios from 'axios';

function MovieForm({ onSubmit }) {
    const [formData, setFormData] = useState({
        name: '',
        description: '',
        trailerLink: ''
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };


    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post('movie', formData);
            console.log(response.data);
            onSubmit();
            setFormData({
                name: '',
                description: '',
                trailerLink: ''
            });
        } catch (error) {
            console.error('Error posting data: ', error);
        }
    }

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="name">Name:</label>
                <input
                    type="text"
                    id="name"
                    name="name"
                    value={formData.name}
                    onChange={handleChange}
                />
            </div>
            <div>
                <label htmlFor="description">Description:</label>
                <input
                    id="description"
                    name="description"
                    value={formData.description}
                    onChange={handleChange}
                />
            </div>
            <div>
                <label htmlFor="trailerLink">Trailer Link:</label>
                <input
                    type="text"
                    id="trailerLink"
                    name="trailerLink"
                    value={formData.trailerLink}
                    onChange={handleChange}
                />
            </div>
            <button type="submit">Add Movie</button>
        </form>
    );
}

export default MovieForm;