import { FC, useState } from "react";
import { AlbumProps } from "../../components/Album/Album";
import { AlbumsList } from "../../components/AlbumsList/AlbumsList";
import { Pagination } from "../../components/Pagination/Pagination";
import styles from "./AlbumPage.module.scss";
import { Picture, PictureProps } from "../../components/Picture/Picture";

export const AlbumPage: FC = () => {
    const [pictures, setPictures] = useState<PictureProps[]>([
        {
            id: "1",
            authorId: "1",
            imgUrl: "https://images.squarespace-cdn.com/content/v1/56b1148fe707ebac7ac5d685/1659916527594-0QOSGRAEFR3ZKPAIRBKI/studying-ahead-1421056.jpg",
            upVotesCount: 2345,
            downVotesCount: 4,
        },
        {
            id: "1",
            authorId: "1",
            imgUrl: "",
            upVotesCount: 5,
            downVotesCount: 13,
        },
        {
            id: "1",
            authorId: "1",
            imgUrl: "https://img.freepik.com/free-photo/painting-mountain-lake-with-mountain-background_188544-9126.jpg",
            upVotesCount: 123,
            downVotesCount: 200,
        },
        {
            id: "1",
            authorId: "1",
            imgUrl: "",
            upVotesCount: 5,
            downVotesCount: 2,
        },
        {
            id: "1",
            authorId: "1",
            imgUrl: "",
            upVotesCount: 5,
            downVotesCount: 2,
        },
    ]);
    return (
        <div className={styles["album-page"]}>
            <div className={styles["container"]}>
                <div className={styles["pictures__list"]}>
                    {pictures.map((picture) => (
                        <Picture {...picture} />
                    ))}
                </div>
                <Pagination
                    currentPage={0}
                    onChangePage={() => {}}
                    totalPages={15}
                />
            </div>
        </div>
    );
};
