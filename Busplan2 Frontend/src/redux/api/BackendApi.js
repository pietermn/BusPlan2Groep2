import axios from 'axios';

const instance = axios.create({
    baseURL: 'http://localhost:5000'
});

instance.interceptors.request.use(
    async (config) => {
        const jwtToken = localStorage.getItem('jwt-token');
        if (jwtToken) {
            config.headers.Authorization = `Bearer ${jwtToken}`;
        }
        return config;
    },
    (err) => {
        return Promise.reject(err)
    }
);

export default instance;