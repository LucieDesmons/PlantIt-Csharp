import { useState, useCallback } from 'react';
import axios from 'axios';
import useToken from '../auth/useToken';

export default function useApi(apiUrl = "localhost:5032") {
  const [list, setList] = useState([]);
  const [item, setItem] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const { token } = useToken();

  // Define POST filter request to pass advanced parameters
  const filter = useCallback(async (klass = "Crypto", data) => {
    try {
      const res = await axios.post(${apiUrl}/filter/${klass}, data, {
        headers: {
          'Authorization': Bearer ${token},
          'Content-Type': 'application/json'
        }
      });
      const resData = Array.isArray(res.data) ? res.data : [res.data];
      setList(resData);
      setLoading(false);
      return resData;
    } catch (err) {
      setError(err);
      setLoading(false);
    }
  }, [token, apiUrl, setList]);
}