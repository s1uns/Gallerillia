import { FC } from "react";
import styles from "./Album.module.scss";
import { Link } from "react-router-dom";

export interface AlbumProps {
    id: string;
    title: string;
    imgUrl: string;
    author: string;
}

export const Album: FC<AlbumProps> = (props: AlbumProps) => {
    return (
        <Link to={`/pictures/${props.id}`}>
            <div className={styles["album"]}>
                <div className={styles["container"]}>
                    <div className={styles["album__image-container"]}>
                        <img
                            className={styles["album__image"]}
                            src={
                                props.imgUrl.length > 0
                                    ? props.imgUrl
                                    : import.meta.env.VITE_BASE_ALBUM_IMG_URL
                            }
                            alt={props.title}
                        />
                    </div>

                    <div className={styles["album__description"]}>
                        <div className={styles["album__description--title"]}>
                            {props.title}
                        </div>
                        <div className={styles["album__description--author"]}>
                            Posted by {props.author}
                        </div>
                    </div>
                </div>
            </div>
        </Link>
    );
};
