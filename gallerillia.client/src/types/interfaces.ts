import { ReactNode } from "react";
import { ButtonType } from "./types";

export interface IHeaderProps {
    isLogged: boolean;
    setIsLogged: (isLogged: boolean) => void;
    currentPage: string;
    setCurrentPage: (currentPage: string) => void;
}

export interface IPageProps {
    isLogged: boolean;
}

export interface IAuthProps {
    setIsLogged: (isLogged: boolean) => void;
    currentPage: string;
    setCurrentPage: (currentPage: string) => void;
}

export interface IAlbumProps {
    id: string;
    title: string;
    imgUrl: string;
    author: string;
    authorId: string;
    canBeManaged: boolean;
    onChange: (isDeleted: boolean) => void;
}

export interface IAlbumListProps {
    albumsType: "all-albums" | "my-albums";
}

export interface IButtonProps {
    children: ReactNode;
    handleClick?: () => void;
    customStyles?: string;
    type?: ButtonType;
    title: string;
    disabled?: boolean;
}

export interface ICredentials {
    email: string;
    password: string;
}

export interface ISignInResult {
    userId: string;
    userRole: string;
    bearer: string;
}

export interface IDeleteDialog {
    entityName: string;
    render: (onClick: () => void) => ReactNode;
    handleAgree: () => void;
}

export interface IUpdateDialog {
    entityName: string;
    render: (onClick: () => void) => ReactNode;
    handleAgree: () => void;
    currentValue: string;
    onChangeValue: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

export interface IPictureProps {
    id: string;
    authorId: string;
    imgUrl: string;
    upVotesCount: number;
    downVotesCount: number;
    usersVote: "UNVOTED" | "UPVOTED" | "DOWNVOTED";
}

export interface IVoteProps {
    isVoted: boolean;
    isPositive: boolean;
    votesCount: number;
}
