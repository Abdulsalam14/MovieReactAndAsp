import { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import MovieForm from './MovieForm';

function MovieList() {
    const [movies, setMovies] = useState(null);

    useEffect(() => {
        getMovies();
    }, []);


    const handleFormSubmit = async () => {
        await getMovies();
    };



    async function handleDelete(id) {
        try {
            await axios.delete(`movie/${id}`);
            await getMovies()
        } catch (error) {
            console.error('Error fetching data: ', error);
        }
    }



    return (
        <div className='movie-list'>
            <div className='list'>
                {movies && movies.map((item, index) => (
                    <div key={index} className='item'>
                        <iframe src={item.trailerLink} title="video" ></iframe>
                        <h2>{item.name}</h2>
                        <p>{item.description}</p>
                        <div>
                            <button onClick={() => handleDelete(item.id)}>
                                <i className="fa-solid fa-xmark"></i>
                            </button>
                        </div>
                    </div>
                ))}
            </div>
            <MovieForm onSubmit={handleFormSubmit}></MovieForm>
        </div>
    );

    async function getMovies() {
        try {
            const response = await axios.get('movie');
            setMovies(response.data);
        } catch (error) {
            console.error('Error fetching data: ', error);
        }
    }



}

export default MovieList;