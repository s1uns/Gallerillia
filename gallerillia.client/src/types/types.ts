import { IAlbumProps, IPictureProps } from "./interfaces";

export type ButtonType = "button" | "submit" | "reset" | undefined;

export type AlbumsList = {
    albums: IAlbumProps[];
    totalPages: number;
};

export type Pictures = {
    pictures: IPictureProps[];
    totalPages: number;
};

export type UpdateAlbumDto = {
    Id: string;
    title: string;
};

export type PaginationProps = {
    currentPage: number;
    onChangePage: (page: number) => void;
    totalPages: number;
};
