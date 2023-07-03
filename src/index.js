import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import Router from './Router'
import reportWebVitals from './reportWebVitals';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <Router />
  </React.StrictMode>
);

reportWebVitals();

/*
const Page = {
  height: 100vh,
  width: 100%,
  margin: 0,
  padding: 0,
  overflowY: auto,
  overflowX: hidden,
  fontFamily: "Roboto", sans-serif,
  position: relative,
  backgroundColor: #FFF0AA
  }
}
*/