import { IAlbumProps, IPictureProps } from "./interfaces";

export type ButtonType = "button" | "submit" | "reset" | undefined;

export type AlbumsList = {
    albums: IAlbumProps[];
    totalPages: number;
};

export type Pictures = {
    pictures: IPictureProps[];
    totalPages: number;
    authorId: string;
};

export type UpdateAlbumDto = {
    Id: string;
    title: string;
};

export type CreateAlbumDto = {
    title: string;
};

export type CreatePictureDto = {
    albumId: string;
    imgUrl: string;
};

export type PaginationProps = {
    currentPage: number;
    onChangePage: (page: number) => void;
    totalPages: number;
};
