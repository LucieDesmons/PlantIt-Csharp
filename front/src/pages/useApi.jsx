import { useState, useCallback } from 'react';
import axios from 'axios';

export default function useApi() {
  const [list, setList] = useState([]);
  const [item, setItem] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const { token } = useToken();
  const urlAuth = "localhost:5032/auth";
  const urlListe = "localhost:5032/Plant/plants";
/*
  // Define POST filter request to pass advanced parameters
  const filter = Auth(async (klass = "ListePlante", data) => {
    try {
      const res = await axios.post({urlAuth}/filter/{klass}, data, {
        headers: {
          'Authorization': Bearer {token},
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
  }, [token, apiUrl, setList]);*/
}