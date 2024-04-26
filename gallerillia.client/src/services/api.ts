import axios from "axios";
import { AlbumProps } from "../components/Album/Album";
import { PictureProps } from "../components/Picture/Picture";

const url = import.meta.env.VITE_ASPNETCORE_HTTPS_PORT
    ? import.meta.env.VITE_ASPNETCORE_HTTPS_PORT
    : "https://localhost:7189/api/";

export type Albums = {
    albums: AlbumProps[];
    totalPages: number;
};

export type Pictures = {
    pictures: PictureProps[];
    totalPages: number;
};

export const fetchAlbums = async (currentPage: number) => {
    const { data } = await axios.get<Albums>(`${url}Album?page=${currentPage}`);

    return data;
};

export const fetchPictures = async (albumId: string, currentPage: number) => {
    const { data } = await axios.get<Pictures>(
        `${url}Picture?albumId=${albumId}&page=${currentPage}`
    );

    return data;
};
