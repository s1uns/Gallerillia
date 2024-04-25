import { FC } from "react";
import { Album, AlbumProps } from "../Album/Album";
import styles from "./AlbumsList.module.scss";

interface AlbumListProps {
    albumsType: string;
    albums: AlbumProps[];
}

export const AlbumsList: FC<AlbumListProps> = (props: AlbumListProps) => {
    return (
        <div className={styles["albums"]}>
            <div className={styles["albums__list"]}>
                {props.albums.map((album) => (
                    <Album key={album.id} {...album} />
                ))}
            </div>
        </div>
    );
};
