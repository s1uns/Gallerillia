import axios from "axios";
import { AlbumProps } from "../components/Album/Album";
import { PictureProps } from "../components/Picture/Picture";

const url = import.meta.env.VITE_ASPNETCORE_HTTPS_PORT
    ? import.meta.env.VITE_ASPNETCORE_HTTPS_PORT
    : "https://localhost:7189/api/";

export type AlbumsList = {
    albums: AlbumProps[];
    totalPages: number;
};

export type Pictures = {
    pictures: PictureProps[];
    totalPages: number;
};

export const fetchAlbums = async (currentPage: number) => {
    const { data } = await axios.get<AlbumsList>(
        `${url}Album?page=${currentPage}`
    );

    return data;
};

export const fetchOwnAlbums = async (currentPage: number) => {
    const bearer = localStorage.getItem("bearer");

    const { data } = await axios.get<AlbumsList>(
        `${url}Album/my-albums?page=${currentPage}`,
        { headers: { Authorization: `Bearer ${bearer}` } }
    );

    return data;
};

export const fetchPictures = async (albumId: string, currentPage: number) => {
    const bearer = localStorage.getItem("bearer");

    const { data } = await axios.get<Pictures>(
        `${url}Picture?albumId=${albumId}&page=${currentPage}`,
        {
            headers: {
                Authorization: `Bearer ${bearer}`,
                "Cache-Control": "no-cache",
            },
        }
    );

    return data;
};

export const voteThePicture = async (pictureId: string, voteStatus: string) => {
    const bearer = localStorage.getItem("bearer");

    const { data } = await axios.post<string>(
        `${url}Picture/vote?pictureId=${pictureId}&voteStatus=${voteStatus}`,
        { headers: { Authorization: `Bearer ${bearer}` } }
    );

    return data;
};
