import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

import Feed from './pages/Feed';
import Register from './pages/Register';
import Profil from './pages/Profil';
import Messagerie from './pages/Messagerie';
import ListePlante from './pages/ListePlante';

//listage des pages
const routes = [
    { path: '/', component: Feed },
    { path: '/', component: Register },
    { path: '/', component: Profil },
    { path: '/', component: Messagerie },
    { path: '/', component: ListePlante }
];

function Router() {
    return (
        <BrowserRouter>
            <Routes>
                {routes.map((route, index) => (
                    //partir sur ListePlantes !!!
                    <Route key={index} path={route.path} element={<route.component />} />
                ))}
            </Routes>
        </BrowserRouter>
    )
}

export default Router;