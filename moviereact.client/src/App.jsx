import { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import MovieList from './MovieList';

function App() {

    return (
        <div>
            <MovieList></MovieList>
        </div>
    );
}

export default App;