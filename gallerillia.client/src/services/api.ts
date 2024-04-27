import axios from "axios";
import { AlbumsList, Pictures, UpdateAlbumDto } from "../types/types";

const url = import.meta.env.VITE_ASPNETCORE_HTTPS_PORT
    ? import.meta.env.VITE_ASPNETCORE_HTTPS_PORT
    : "https://localhost:7189/api/";

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

export const deleteAlbum = async (albumId: string) => {
    const bearer = localStorage.getItem("bearer");

    const { data } = await axios.delete<string>(`${url}Album/${albumId}`, {
        headers: { Authorization: `Bearer ${bearer}` },
    });

    return data;
};

export const updateAlbum = async (updateAlbumDto: UpdateAlbumDto) => {
    const bearer = localStorage.getItem("bearer");

    const { data } = await axios.put<string>(`${url}Album`, updateAlbumDto, {
        headers: { Authorization: `Bearer ${bearer}` },
    });

    return data;
};

export const fetchPictures = async (albumId: string, currentPage: number) => {
    const bearer = localStorage.getItem("bearer");

    const { data } = await axios.get<Pictures>(
        `${url}Picture?albumId=${albumId}&page=${currentPage}`,
        {
            headers: {
                Authorization: `Bearer ${bearer}`,
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
