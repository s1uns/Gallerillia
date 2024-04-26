import { FC } from "react";
import { Album, AlbumProps } from "../Album/Album";
import styles from "./AlbumList.module.scss";

interface AlbumListProps {
    albums: AlbumProps[];
}

export const AlbumList: FC<AlbumListProps> = (props: AlbumListProps) => {
    const userId = localStorage.getItem("userId");
    const userRole = localStorage.getItem("userRole");
    return (
        <div className={styles["albums"]}>
            <div className={styles["albums__list"]}>
                {props.albums.map((album) => (
                    <Album
                        key={album.id}
                        id={album.id}
                        title={album.title}
                        imgUrl={album.imgUrl}
                        author={album.author}
                        authorId={album.authorId}
                        canBeDeleted={
                            userId == album.authorId ||
                            userRole == "Administrator"
                        }
                    />
                ))}
            </div>
        </div>
    );
};
